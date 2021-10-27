import { DocumentTemplateDataModel } from "./DocumentTemplateDataModel";

export class DocumentTemplateModel {
	public ID: number;
	public OrganizationID: number;
	public CreatorID: number;
	public FlowTemplate: number;
	public Data: string;
	public templateData: DocumentTemplateDataModel;
}