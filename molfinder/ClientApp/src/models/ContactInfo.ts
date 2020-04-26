import Address from "./Address";

export default class ContactInfo {
    public languageCode: number;
    public firstName: string;
    public lastName: string;
    public middleName: string;
    public email: string;
    public contactAddress: Address;
    public phone: string;
    public mobile: string;
    public fax: string;
    public memo: string;

    constructor(languageCode: number, firstName: string, lastName: string, middleName: string, email: string, contactAddress: Address, phone: string, mobile: string, fax: string, memo: string) {
        this.languageCode = languageCode;
        this.firstName = firstName;
        this.lastName = lastName;
        this.middleName = middleName;
        this.email = email;
        this.contactAddress = contactAddress;
        this.phone = phone;
        this.mobile = mobile;
        this.fax = fax;
        this.memo = memo;
    }
}