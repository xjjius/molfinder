import React, {Component} from 'react';
import {Col, ListGroup, ListGroupItem} from "reactstrap";
import CalculatedProperty from "../../models/CalculatedProperty";
import {v4 as uuidv4} from 'uuid';
import labels from "../../config/Labels";
import intl from 'react-intl-universal';

export default class CalculatedProperties extends Component<any, any> {
    // 按程序表好分组
    groupByProgramCode(rawData: Array<CalculatedProperty>): Array<CalculatedPropertiesGroup> {
        let result = new Array<CalculatedPropertiesGroup>();
        // get unique programCode first
        let programCodes: Set<number> = new Set([...rawData.map(d => d.programCode)]);
        programCodes.forEach((code) => {
            let temp = new CalculatedPropertiesGroup();
            temp.programCode = code;
            temp.calculatedProperties.push(
                ...rawData.filter(d => d.programCode === code)
            );
            result.push(temp);
        });
        return result;
    }

    render() {
        let list: Array<CalculatedProperty> = this.props.data;
        let programGroup: Array<CalculatedPropertiesGroup> = this.groupByProgramCode(list);
        console.log(programGroup);
        if (list.length > 0) {
            return (
                <ListGroup className='mb-sm-3'>
                    <ListGroupItem key={uuidv4()} active>
                        {intl.get("Calculated Properties")}
                    </ListGroupItem>
                    <ListGroupItem key={uuidv4()}>
                        {
                            programGroup.map((p) =>
                                <div className="row">
                                    <div className="col-12 border-bottom">
                                        {labels.getProgramNameByCode(p.programCode)}
                                    </div>
                                    {
                                        p.calculatedProperties.map((l) =>
                                            (
                                                <>
                                                    <div className="col-sm-3 border-bottom">
                                                        {labels.getPropertyDescriptionByCode(l.propertyCode)}
                                                    </div>
                                                    <div className="col-sm-9 border-bottom">
                                                        <span dangerouslySetInnerHTML={{__html: l.propertyText}}/>
                                                    </div>
                                                </>
                                            )
                                        )
                                    }
                                </div>
                            )
                            /*programGroup.map((p) =>
                                <ListGroup className='mb-sm-3'>
                                    <ListGroupItem key={uuidv4()} active>
                                        {labels.getProgramNameByCode(p.programCode)}
                                    </ListGroupItem>
                                    {
                                        p.calculatedProperties.map((l) =>
                                            <ListGroupItem key={uuidv4()}>
                                                <span>{labels.getPropertyDescriptionByCode(l.propertyCode)}</span>&nbsp;:&nbsp;
                                                <span dangerouslySetInnerHTML={{__html: l.propertyText}}/>
                                            </ListGroupItem>
                                        )
                                    }
                                </ListGroup>
                            )*/
                        }
                    </ListGroupItem>
                </ListGroup>
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

class CalculatedPropertiesGroup {
    programCode: number = 0;
    calculatedProperties: Array<CalculatedProperty> = new Array<CalculatedProperty>();
}

