import React, {Component} from 'react';
import MoleculeDataSource from "../../models/MoleculeDataSource";
import {Col, ListGroup, ListGroupItem, Row} from "reactstrap";
import {v4 as uuidv4} from 'uuid';
import labels from "../../config/Labels";
import DataSource from "../../models/DataSource";

export default class DataSources extends Component<any, any> {
    constructor(props: any) {
        super(props);
        this.state = {data: []};
    }

    componentDidMount(): void {
        let submitUrl = '/api/moleculeDataSource?molID=' + this.props.molID;
        fetch(submitUrl, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json;charset=UTF-8'
            },
            mode: 'cors',
            cache: 'default'
        })
            .then(response => response.json())
            .then((result) => {
                //console.log(result);
                let data = this.groupDataSourceByType(result as Array<MoleculeDataSource>);
                console.log(data);
                this.setState({data: data});
                let pubChemCID = (result as Array<MoleculeDataSource>).find(r => r.companyIntId === 17)?.extID;
                this.props.pubChemCIDCallBack(pubChemCID);
            })
            .catch(e => console.log("Oops, error", e));
    }

    groupDataSourceByType(rawData: Array<MoleculeDataSource>): Array<MoleculeDataSourceTypeGroup> {
        let result = new Array<MoleculeDataSourceTypeGroup>();
        let uniqueDataSourceTypes: Set<number> = new Set([...rawData.map(d => d.dataSourceType)]);
        uniqueDataSourceTypes.forEach((dataSourceType) => {
            let companyGroups = rawData.filter(d => d.dataSourceType === dataSourceType);
            let uniqueCompanyIntId: Set<number> = new Set([...companyGroups.map(c => c.companyIntId)]);
            //console.log(uniqueCompanyIntId);
            let temp = new Array<MoleculeDataSourceCompanyGroup>();
            uniqueCompanyIntId.forEach((companyIntId) => {
                temp.push(new MoleculeDataSourceCompanyGroup(
                    dataSourceType,
                    companyIntId,
                    companyGroups.filter(c => c.companyIntId === companyIntId)
                ));
            });
            //console.log(temp);
            result.push(new MoleculeDataSourceTypeGroup(dataSourceType, temp));
        });
        return result;
    }

    getExternalUrl(dataSource: DataSource | undefined, extId: string): string | undefined {
        let urlPattern = dataSource?.dataSourceDescriptions
            .find(dp => dp.languageCode === labels.getCurrentLanguageCode())?.url;
        return urlPattern?.replace('{0}', extId);
    }

    render() {
        if (this.state.data.length !== 0) {
            let dataSourceGroups = this.state.data as Array<MoleculeDataSourceTypeGroup>;
            return (
                <Col xs="12">
                    <ListGroup className='mb-sm-3'>
                        <ListGroupItem key={uuidv4()} active>
                            Data Source
                        </ListGroupItem>
                        <ListGroupItem key={uuidv4()}>
                            {
                                dataSourceGroups.map((d) =>
                                    <ListGroup className='mb-sm-3'>
                                        <ListGroupItem key={uuidv4()} active>
                                            {d.dataSourceType}
                                        </ListGroupItem>
                                        {
                                            d.moleculeDataSources.map((dd) =>
                                                <ListGroupItem key={uuidv4()}>
                                                    <Row>
                                                        <Col xs="2">
                                                            <abbr
                                                                title={dd.moleculeDataSources.find(md => md.companyIntId === dd.companyIntId)
                                                                    ?.companyInformation.find(l => l.languageCode === labels.getCurrentLanguageCode())
                                                                    ?.fullName}>
                                                                {
                                                                    dd.moleculeDataSources.find(md => md.companyIntId === dd.companyIntId)
                                                                        ?.companyInformation.find(l => l.languageCode === labels.getCurrentLanguageCode())
                                                                        ?.shortName
                                                                }
                                                            </abbr>
                                                        </Col>
                                                        {
                                                            dd.moleculeDataSources.map((ddd) => {
                                                                    let dataSource = ddd.dataSources.find(ds => ds.dataSourceIntId === ddd.dataSourceIntId);
                                                                    let url = this.getExternalUrl(dataSource, ddd.extID)? this.getExternalUrl(dataSource, ddd.extID): ddd.extUrl;
                                                                    return (
                                                                        <>
                                                                            <Col xs="1">
                                                                                <a href={url}
                                                                                   rel="noopener noreferrer"
                                                                                   target='_blank'>{ddd.extID}</a>
                                                                            </Col>
                                                                        </>
                                                                    );
                                                                }
                                                            )
                                                        }
                                                    </Row>
                                                </ListGroupItem>
                                            )
                                        }
                                    </ListGroup>
                                )
                            }
                        </ListGroupItem>
                    </ListGroup>
                </Col>
            );
        } else {
            return (
                "Loading..."
            );
        }
    }
}

class MoleculeDataSourceTypeGroup {
    public dataSourceType: number;
    public moleculeDataSources: Array<MoleculeDataSourceCompanyGroup> = new Array<MoleculeDataSourceCompanyGroup>();

    constructor(dataSourceType: number, moleculeDataSources: Array<MoleculeDataSourceCompanyGroup>) {
        this.dataSourceType = dataSourceType;
        this.moleculeDataSources = moleculeDataSources;
    }
}

class MoleculeDataSourceCompanyGroup {
    public dataSourceType: number;
    public companyIntId: number;
    public moleculeDataSources: Array<MoleculeDataSource> = new Array<MoleculeDataSource>();


    constructor(dataSourceType: number, companyIntId: number, moleculeDataSources: Array<MoleculeDataSource>) {
        this.dataSourceType = dataSourceType;
        this.companyIntId = companyIntId;
        this.moleculeDataSources = moleculeDataSources;
    }
}
