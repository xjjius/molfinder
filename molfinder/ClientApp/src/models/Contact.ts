import ContactInfo from "./ContactInfo";

export default class Contact {
    public contactInfo: Array<ContactInfo>;
    public nickName: string;
    public timeCreated: Date;

    constructor(contactInfo: Array<ContactInfo>, nickName: string, timeCreated: Date) {
        this.contactInfo = contactInfo;
        this.nickName = nickName;
        this.timeCreated = timeCreated;
    }
}