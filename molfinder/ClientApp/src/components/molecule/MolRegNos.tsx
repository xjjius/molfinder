import React, {Component} from 'react';
import MolRegNo from "../../models/MolRegNo";
import {Col, ListGroup, ListGroupItem} from "reactstrap";
import {v4 as uuidv4} from 'uuid';
import labels from "../../config/Labels";
import intl from "react-intl-universal";

export default class MolRegNos extends Component<any, any> {
    constructor(props: any) {
        super(props);
        this.state = {data: []};
    }

    componentDidMount() {
        let submitUrl: string = "/api/molregnos?molID=" + this.props.molID;
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

    render() {
        let molRegNoGroups: Array<MolRegNoGroup> = this.state.data;
        if (molRegNoGroups.length !== 0) {
            return (
                <Col xs="12">
                    <ListGroup className='mb-sm-3'>
                        <ListGroupItem key={uuidv4()} active>
                            {intl.get("Registration numbers")}
                        </ListGroupItem>
                        <ListGroupItem key={uuidv4()}>
                            {
                                molRegNoGroups.map((r) => {
                                    console.log(uuidv4());
                                    return (
                                        <ListGroup className='mb-sm-3'>
                                            <ListGroupItem key={uuidv4()} active>
                                                {labels.getRegTypeByCode(r.regType)}
                                            </ListGroupItem>
                                            {
                                                r.molRegNos.map((rr) => (
                                                    <ListGroupItem key={uuidv4()}>
                                                        <a href={labels.getRegUrlByRegNo(rr.regNoValue, rr.regType)}
                                                           rel="noopener noreferrer"
                                                           target='_blank'>{rr.regNoValue}</a>
                                                    </ListGroupItem>
                                                ))
                                            }
                                        </ListGroup>
                                    );
                                })
                            }
                        </ListGroupItem>
                    </ListGroup>
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

class MolRegNoGroup {
    public regType: number;
    public molRegNos: Array<MolRegNo>;

    constructor(regType: number, molRegNos: Array<MolRegNo>) {
        this.regType = regType;
        this.molRegNos = molRegNos;
    }
}