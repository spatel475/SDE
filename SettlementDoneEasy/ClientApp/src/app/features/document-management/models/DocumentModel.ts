import { DocumentAuditModel } from "./DocumentAuditModel";
import { DocumentDataModel } from "./DocumentDataModel";
import { DocumentTemplateModel } from "./DocumentTemplateModel";

export class DocumentModel {
	public ID: number;
	public UserId: number;
	public Data: string;
	public TemplateID: number;
	public CreationDate: Date;
	public Title: string;


	public Template: DocumentTemplateModel;
	public Audits: DocumentAuditModel[];
	public DocumentData: DocumentDataModel;
}


