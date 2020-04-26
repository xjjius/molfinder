import React, {Component} from 'react';
import Property from "../../models/Property";
import {Col, CustomInput, ListGroup, ListGroupItem, Row} from "reactstrap";
import labels from "../../config/Labels";
import {emit} from "../utils/emit";
import {v4 as uuidv4} from 'uuid';
import PropertyProvider from "./PropertyProvider";

export default class Properties extends Component<any, any> {
    constructor(props: any) {
        super(props);
        this.state = {data: null, showSource: []};
    }

    componentDidMount(): void {
        let submitUrl: string = "/api/moleculeProperty?molID=" + this.props.molID;
        fetch(submitUrl, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json;charset=UTF-8'
            },
            mode: 'cors',
            cache: 'default'
        })
            .then(response => response.json())
            .then(result => {
                console.log(result);
                this.setState({data: result});
            })
            .catch(e => console.log("Oops, error", e));
    }

    showProvider = (event: any) => {
        //console.log(event.target.id);
        emit.emit('show_provider_' + event.target.id.toString(), event.target.id);

    };

    groupPropertiesByValue(properties: Array<Property>): Array<PropertyValueGroup> {
        let valueGroup = properties.reduce((ubc: any, u) =>
                ({
                    ...ubc,
                    [u.propertyValue]: [...(ubc[u.propertyValue] || []), u],
                }),
            {});
        let propertyValueGroup = new Array<PropertyValueGroup>();
        for (let valueGroupKey in valueGroup) {
            propertyValueGroup.push(new PropertyValueGroup(valueGroupKey, valueGroup[valueGroupKey]));
            //console.log(item);
        }
        return propertyValueGroup;
    }

    render() {
        let propertiesGroup: Array<PropertyGroup> = this.state.data;
        //console.log(propertiesGroup);
        if (propertiesGroup !== null) {
            return (
                <Col xs="12">
                    {
                        propertiesGroup.map(p => {
                            return (
                                <ListGroup className='mb-sm-3'>
                                    <ListGroupItem key={uuidv4()} active>
                                        {labels.getPropCategoryByCode(p.propertyCategory)}
                                    </ListGroupItem>
                                    <ListGroupItem key={uuidv4()}>
                                        {
                                            p.properties.map(pp => {
                                                let propertyValueGroup = this.groupPropertiesByValue(pp.properties);
                                                return (
                                                    <ListGroup className='mb-sm-3'>
                                                        <ListGroupItem key={uuidv4()} active>
                                                            <span
                                                                dangerouslySetInnerHTML={{__html: labels.getPropertyDescriptionByCode(pp.propertyCode) as string}}/>
                                                        </ListGroupItem>
                                                        {
                                                            propertyValueGroup.map((ppp) => {
                                                                return (
                                                                    <ListGroupItem key={uuidv4()}>
                                                                        <Row>
                                                                            <Col xs={7}
                                                                                 dangerouslySetInnerHTML={{__html: labels.displayPropertyByValue(ppp.propertyValue, pp.propertyCode)}}
                                                                            />
                                                                            <Col xs={4}>
                                                                                <PropertyProvider
                                                                                    substanceIDs={ppp.properties.map(s => s.substanceID)}
                                                                                    propertyCode={pp.propertyCode}
                                                                                    propertyValue={ppp.propertyValue}
                                                                                />
                                                                            </Col>
                                                                            <Col xs={1}>
                                                                                <span style={{float: "right"}}>
                                                                                    <CustomInput
                                                                                        type="switch"
                                                                                        id={pp.propertyCode + "_" + ppp.propertyValue}
                                                                                        label="Source"
                                                                                        onClick={(e) => this.showProvider(e)}
                                                                                    />
                                                                                </span>
                                                                            </Col>
                                                                        </Row>
                                                                    </ListGroupItem>
                                                                )
                                                            })
                                                        }
                                                    </ListGroup>
                                                );
                                            })
                                        }
                                    </ListGroupItem>
                                </ListGroup>
                            );
                        })
                    }
                </Col>
            );
        } else {
            return (
                <Col xs="12">
                    Loading...
                </Col>
            );
        }
    }

}

class PropertyGroup {
    propertyCategory: number;
    properties: Array<PropertyTypeGroup> = new Array<PropertyTypeGroup>();

    constructor(propertyCategory: number, properties: Array<PropertyTypeGroup>) {
        this.propertyCategory = propertyCategory;
        this.properties = properties;
    }
}

class PropertyTypeGroup {
    propertyCode: number;
    properties: Array<Property> = new Array<Property>();

    constructor(propertyType: number, properties: Array<Property>) {
        this.propertyCode = propertyType;
        this.properties = properties;
    }
}

class PropertyValueGroup {
    propertyValue: string;
    properties: Array<Property> = new Array<Property>();

    constructor(propertyValue: string, properties: Array<Property>) {
        this.propertyValue = propertyValue;
        this.properties = properties;
    }
}