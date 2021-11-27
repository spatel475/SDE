export class DocumentData {

	public ClaimNum: number;
	public ClaimantName: string;
	public DateOfAccident: Date;
	public InsuredName: string;
	public LawFirmTaxID: number;
	public LawyerName: string;
	public PlaceOfAccident: string;
	public Receiver: string;
	public Sender: string;
	public SettlementAmount: number;

	public static FromJson(str: string) {
		return JSON.parse(str);
	}

	public static ToJson(data: DocumentData) {
		return JSON.stringify(data);
	}

	public ToJson() {
		return JSON.stringify(this);
	}
}