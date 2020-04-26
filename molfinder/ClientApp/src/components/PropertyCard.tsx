import React, {Component} from 'react';
import {Col, ListGroup, ListGroupItem} from "reactstrap";
import Languages from "../config/Languages";
import intl from "react-intl-universal";
import PreProperty from "../config/PreProperty";
import Description from "../config/Description";

export class PropertyCard extends Component<any, any> {
    constructor(props: any) {
        super(props);
        this.state = {currentLanguage: props.language};
        console.log(props.data);
    }

    private readonly languages = new Languages();

    getDescriptionForCurrentLocale(descriptions: Array<Description>): string {
        let langCode: number = this.languages.getLangCodeByLocaleText(intl.getInitOptions().currentLocale);
        let ret = descriptions.find((value: any) => value.langCode === langCode);
        // @ts-ignore
        return ret.text;
    }

    render() {
        let properties: Array<PreProperty> = this.props.data.preProperties || [];
        //alert("rendering properties...");
        console.log(properties);
        return (
            <Col xs="12">
                <ListGroup>
                    {
                        properties.map((p) =>
                            (
                                <ListGroupItem key={p.code}>
                                    <span>{p.code}</span>&nbsp;-&nbsp;
                                    <span
                                        dangerouslySetInnerHTML={{__html: this.getDescriptionForCurrentLocale(p.descriptions)}}/>
                                </ListGroupItem>
                            )
                        )
                    }
                </ListGroup>
            </Col>
        );
    }
}