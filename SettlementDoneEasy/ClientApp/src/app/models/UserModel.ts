import { OrganizationModel } from "./OrganizationModel";

export class UserModel {
	public id: number;
	public username: string;
	public email: string;
	public password: string;
	public organization: OrganizationModel;
}
