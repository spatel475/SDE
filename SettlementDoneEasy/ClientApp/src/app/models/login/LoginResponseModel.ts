import { UserModel } from "../UserModel"

export class LoginReponseModel {
	public isAuthSuccessful: boolean
	public errorMessage: string
	public token: string
	public user: UserModel
}