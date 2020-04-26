import React, {Component} from 'react';
import {Spinner} from 'reactstrap';
import {emit} from "../utils/emit";
import SubstanceSupplier from "../../models/SubstanceSupplier";
import labels from "../../config/Labels";

const FontAwesome = require('react-fontawesome');

export default class PropertyProvider extends Component<any, any> {
    constructor(props: any) {
        super(props);
        this.state = {hidden: true, supplierInfo: new Array<SubstanceSupplier>()};
    }

    componentDidMount(): void {
        emit.on('show_provider_' + this.props.propertyCode + '_' + this.props.propertyValue,
            () => {
                //console.log(this.props.propertyCode + '_' + this.props.propertyValue);
                this.setState({hidden: !this.state.hidden});
                if (this.state.supplierInfo.length === 0) {
                    this.loadSupplierInfo(this.props.substanceIDs);
                }
            }
        );
    }

    loadSupplierInfo(substanceIDs: Array<number>): void {
        let submitUrl = '/api/suppliers';
        fetch(submitUrl, {
            method: 'POST',
            body: JSON.stringify(substanceIDs),
            headers: {
                'Content-Type': 'application/json;charset=UTF-8'
            },
            mode: 'cors',
            cache: 'default'
        })
            .then(response => response.json())
            .then(result => {
                console.log(result);
                this.setState({supplierInfo: result as Array<SubstanceSupplier>});
            })
            .catch(e => console.log("Oops, error", e));
    }

    render() {
        if (this.state.hidden) {
            return "";
        } else {
            if (this.state.supplierInfo.length !== 0) {
                return (
                    this.state.supplierInfo.map((prop: SubstanceSupplier) =>
                        <div>
                            <a href={`/company/${prop.company.companyIntId}`}>
                                {prop.company.companyInformation
                                    .find(c => c.languageCode === labels.getCurrentLanguageCode())
                                    ?.shortName
                                }
                            </a>
                            &nbsp;-&nbsp;
                            <a href={`/substance/${prop.substanceID}`} target="_blank" rel="noopener noreferrer">{prop.extID}</a>
                            &nbsp;
                            <a href={prop.extUrl} target="_blank" rel="noopener noreferrer">
                                <FontAwesome name="external-link" />
                            </a>
                        </div>
                    )
                );
            } else {
                return (
                    <span>
                        &nbsp;&nbsp;
                        <Spinner color="primary" size="sm"/>
                    </span>
                );
            }
        }
    }
}