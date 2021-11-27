import { DocumentAuditModel } from "./DocumentAuditModel";
import { DocumentData } from "./DocumentData";
import { DocumentDataModel } from "./DocumentDataModel";
import { DocumentTemplateModel } from "./DocumentTemplateModel";

export class DocumentModel {
	public id: number;
	public userId: number;
	public data: any | DocumentData;
	public templateID: number;
	public creationDate: Date;
	public title: string;


	public template: DocumentTemplateModel;
	public audits: DocumentAuditModel[];
	public documentData: DocumentDataModel;
}


