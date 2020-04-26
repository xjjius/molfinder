export default class Address {
    public country: string;
    public state: string;
    public city: string;
    public streetAddress: string;
    public zipCode: string;

    constructor(country: string, state: string, city: string, streetAddress: string, zipCode: string) {
        this.country = country;
        this.state = state;
        this.city = city;
        this.streetAddress = streetAddress;
        this.zipCode = zipCode;
    }
}