
class DocumentModel {
	public ID: number;
	public UserId: number;
	public Data: string;
	public TemplateID: number;


	public Template: DocumentTemplateModel;
	public Audits: DocumentAuditModel[];
	public DocumentData: DocumentDataModel;
}
