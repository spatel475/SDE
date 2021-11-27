using Microsoft.EntityFrameworkCore;
using SDE_Server.Domain.Entities;
using SDE_Server.Domain.ReleaseStatemachine;
using SDE_Server.Models.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDE_Server.Domain.Repositories
{
    public class DocumentRepository
    {
        private SDEDBContext _dbContext;

        public DocumentRepository()
        {
            _dbContext = new SDEDBContext();
        }

        public async Task Create(DocumentModel document) 
        {
            var docEntity = document.MapToEntity();
            docEntity.DocumentAudit.Add(new DocumentAudit()
            {
                CreationDate = DateTime.Now,
                Description = "Initial Creation",
                FlowState = new ReleaseMachine().ToJson(),
                State = (int)ReleaseState.P1_Draft,                
            });


            //_dbContext.Document.Add(document.MapToDocument());
            _dbContext.Document.Add(docEntity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(DocumentModel document)
        {
            //Document existingDoc = await _dbContext.Document.FirstOrDefaultAsync(d => d.ID == document.ID);

            _dbContext.Update(document.MapToEntity());

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int docId)
        {
            // Should not be actually deleting. Just modifying the status to archieved.
            throw new NotImplementedException();
        }

        public async Task<List<DocumentModel>> GetDocumentsByUser(int userId)
        {
            List<Document> docs =
                await _dbContext.Document
                    .Where(d => d.UserID == userId)
                    .Include(doc => doc.DocumentAudit)
                    .Include(doc => doc.DocumentData)
                    .Include(doc => doc.DocumentUser)
                    .Include(doc => doc.Template.DocumentTemplateData) 
                    .ToListAsync();

            return docs.Select(d => DocumentModel.MapFromEntity(d)).ToList();
        }

        public async Task<ReleaseStateInfo>GetStateInfo(DocumentModel document, string userEmail)
        {
            var lastAudit = document.GetLatestAudit();
            ReleaseMachine stateMachine = ReleaseMachine.FromJson(lastAudit.FlowState);

            return stateMachine.GetStateInfo();
        }

        internal bool ChangeState(DocumentModel document, int trigger)
        {
            var lastAudit = document.GetLatestAudit();
            ReleaseMachine stateMachine = ReleaseMachine.FromJson(lastAudit.FlowState);

            if (!stateMachine.CanFire((ReleaseTrigger)trigger))
                return false;

            stateMachine.Fire((ReleaseTrigger)trigger);
            stateMachine.Triggers.TryGetValue((ReleaseTrigger)trigger, out ReleaseStateTrigger triggerInfo);


            var audit = new DocumentAudit() {
                CreationDate = DateTime.Now,
                Description = triggerInfo.Description,
                DocID = document.ID,
                FlowState = stateMachine.ToJson(),
                State = (int)stateMachine.State
            };

            _dbContext.Add(audit);
            _dbContext.SaveChangesAsync();

            return true;
        }

        private async Task<DocumentDataModel> GetDocumentData(int docId)
        {
            DocumentData documentData = await _dbContext.DocumentData.FirstOrDefaultAsync(d => d.ID == docId);
            return new DocumentDataModel
            {
                ID = documentData.ID,
                AdjustedData = Convert.ToBase64String(documentData.AdjustedData),
                ArchiveData = Convert.ToBase64String(documentData.ArchiveData)  
            };
        }
    }
}
