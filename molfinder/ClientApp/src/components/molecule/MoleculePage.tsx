import React, {Component} from 'react';
import {ListGroup, ListGroupItem, Row, Col} from "reactstrap";
import CalculatedProperties from "./CalculatedProperties";
import Molecule from "../../models/Molecule";
import MoleculeBase from "../../models/MoleculeBase";
import BasicInfo from "./BasicInfo";
import Properties from "./Properties";
import MolNames from "./MolNames";
import MolRegNos from "./MolRegNos";
import DataSources from "./DataSources";
import {v4 as uuidv4} from "uuid";
import PubChemBioAssay from "./PubChemBioAssay";

export class MoleculePage extends Component<any, any> {

    static displayName = MoleculePage.name;

    constructor(props: any) {
        super(props);
        this.state = {data: [], isLoaded: false};
        //console.log(labels.config);
    }

    componentDidMount() {
        //console.log(this.props.molId);
        this.loadMoleculeById(this.props.molId);
    }

    loadMoleculeById(id: number) {
        if (!id) {
            id = 10000;
        }
        let submitUrl = '/api/molecule?molID=' + id;
        //alert(submitUrl);
        //console.log(submitUrl);
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
                this.setState({data: result, isLoaded: true});
            })
            .catch(e => console.log("Oops, error", e));
    }

    getPucChemCIDFromChild(e: number) {
        console.log(e);
        this.setState({pubChemCID: e});
    }

    render() {
        if (this.state.isLoaded) {
            let mol: Molecule = this.state.data;
            //console.log(mol.calculatedProperties);
            let molBasicInfo: MoleculeBase = new MoleculeBase(mol.molFile, mol.isomericSmiles, mol.canonicSmiles,
                mol.exactMass, mol.mass, mol.formula, mol.charge, mol.inChI, mol.inChIKey);
            return (
                <Row>
                    <BasicInfo data={molBasicInfo}/>
                    <MolNames molID={this.props.molId}/>
                    <MolRegNos molID={this.props.molId}/>
                    <CalculatedProperties data={mol.calculatedProperties}/>
                    <Properties molID={this.props.molId}/>
                    <DataSources molID={this.props.molId}
                                 pubChemCIDCallBack={(e: number) => this.getPucChemCIDFromChild(e)}/>
                    <Col xs={12}>
                        <ListGroup className='mb-sm-3'>
                            <ListGroupItem key={uuidv4()} active>
                                PubChem BioAssay
                            </ListGroupItem>
                            <ListGroupItem key={uuidv4()}>
                                <PubChemBioAssay pubChemCID={this.state.pubChemCID}/>
                            </ListGroupItem>
                        </ListGroup>
                    </Col>
                    {/*<PubChemBioAssay pubChemCID={cid}/>*/}
                    {/*<PropList data={mol}/>*/}
                </Row>
            );
        } else {
            return (
                <Row>
                    Loading....
                </Row>
            );
        }

    }
}