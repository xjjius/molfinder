import React, {Component} from 'react';
import {Badge, Col, ListGroup, ListGroupItem} from "reactstrap";
import MolName from "../../models/MolName";
import labels from "../../config/Labels";
import {v4 as uuidv4} from 'uuid';
import intl from 'react-intl-universal';

export default class MolNames extends Component<any, any> {
    constructor(props: any) {
        super(props);
        this.state = {data: []};
    }

    componentDidMount() {
        let submitUrl: string = "/api/molnames?molID=" + this.props.molID;
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
        let molNameGroups: Array<MolNameGroup> = this.state.data;
        if (molNameGroups.length !== 0) {
            return (
                <Col xs="12">
                    <ListGroup className='mb-sm-3'>
                        <ListGroupItem key={uuidv4()} active>
                            {intl.get("Names and Identifiers")}
                        </ListGroupItem>
                        <ListGroupItem key={uuidv4()}>
                            {
                                molNameGroups.map((ng) =>
                                    <ListGroup className='mb-sm-3'>
                                        <ListGroupItem key={uuidv4()}
                                                       active>{labels.getSynNameTypeByCode(ng.nameType)}</ListGroupItem>
                                        <ListGroupItem key={uuidv4()}
                                                       style={{
                                                           overflow: "auto",
                                                           textOverflow: "ellipsis",
                                                           wordWrap: "break-word",
                                                           wordBreak: "break-word"
                                                       }}>
                                            {
                                                ng.molNames.map((n) =>
                                                    <Badge color='dark' className='mr-sm-2'>
                                                        <span
                                                            dangerouslySetInnerHTML={{__html: n.nameText}}
                                                        />
                                                    </Badge>
                                                )
                                            }
                                        </ListGroupItem>
                                    </ListGroup>
                                )
                            }
                        </ListGroupItem>
                    </ListGroup>
                </Col>
            )
        } else {
            return (
                <Col xs="12">
                    Loading...
                </Col>
            );
        }
    }
}

class MolNameGroup {
    public nameType: number;
    public molNames: Array<MolName>;

    constructor(nameType: number, molNames: Array<MolName>) {
        this.nameType = nameType;
        this.molNames = molNames;
    }
}