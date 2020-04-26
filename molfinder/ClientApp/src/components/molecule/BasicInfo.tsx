import React, {Component} from 'react';
import {Col, ListGroup, ListGroupItem} from "reactstrap";
import MoleculeBase from "../../models/MoleculeBase";
import MolImage from "./MolImage";
import intl from 'react-intl-universal';
import labels from "../../config/Labels";
import {v4 as uuidv4} from "uuid";

class BasicInfo extends Component<any, any> {
    render() {
        let mol: MoleculeBase = this.props.data;
        console.log(mol);
        if (mol == null) {
            return (
                <Col xs="12">
                    Loading...
                </Col>
            );
        } else {
            return (
                <Col xs="12">
                    <ListGroup className='mb-sm-3'>
                        <ListGroupItem key={uuidv4()} active>
                            {intl.get("General Information")}
                        </ListGroupItem>
                        <ListGroupItem key={uuidv4()}>
                            <MolImage molBase={mol}/>
                        </ListGroupItem>
                        <ListGroupItem key={uuidv4()}>
                            Isomeric SMILES: {mol.isomericSmiles}
                        </ListGroupItem>
                        <ListGroupItem key={uuidv4()}>
                            Canonical SMILES: {mol.canonicSmiles}
                        </ListGroupItem>
                        <ListGroupItem key={uuidv4()}>
                            {intl.get("formula")}: {labels.convertSubscripts(mol.formula)}
                        </ListGroupItem>
                        <ListGroupItem key={uuidv4()}>
                            {intl.get("mass")}: {mol.mass}
                        </ListGroupItem>
                        <ListGroupItem key={uuidv4()}>
                            {intl.get("exactMass")}: {mol.exactMass}
                        </ListGroupItem>
                        <ListGroupItem key={uuidv4()}>
                            {intl.get("charge")}: {mol.charge}
                        </ListGroupItem>
                        <ListGroupItem key={uuidv4()}>
                            {intl.get("inChI")}: {mol.inChI}
                        </ListGroupItem>
                        <ListGroupItem key={uuidv4()}>
                            {intl.get("inChIKey")}: {mol.inChIKey}
                        </ListGroupItem>
                    </ListGroup>
                </Col>
            );
        }
    }
}

export default BasicInfo;