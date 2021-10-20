export class RegexUtils {
	/**
	 * This regex will enforce these rules:
	 * 
	 * - At least one English letter, (?=.*?[A-Za-z])
	 * 
	 * - At least one digit, (?=.*\d)
	 * 
	 * - At least one special character, (?=.[$@$!% #+=()\^?&]) Add more if you like...
	 * 
	 * - Minimum length of 6 characters (?=.[$@$!% #?&])[A-Za-z\d$@$!%* #+=()\^?&]{6,} include spaces
	 * 
	 * If you want to add more special characters, you can add it to the Regex like I have added '(' (you need to add it in two places).
	 */
	public static passwordValidator(str: string): boolean {
		return !!str?.match(/^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%* #+=\(\)\^?&])[A-Za-z\d$@$!%* #+=\(\)\^?&]{6,}$/);
	}

}
