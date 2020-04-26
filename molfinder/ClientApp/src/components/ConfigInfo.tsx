import * as React from "react";
import {Row} from "reactstrap";
import {PropertyCard} from "./PropertyCard"
import labels from "../config/Labels";

export class ConfigInfo extends React.Component<any, any> {
    render() {
        return (
            <Row>
                <PropertyCard data={labels.config} language={this.props.locale}/>
                {/*<PropList data={this.state.data}/>*/}
            </Row>
        );
    }
}