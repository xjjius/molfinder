import * as React from "react";
import {Col, ListGroup, ListGroupItem} from "reactstrap";

export class PropList extends React.Component<any, any> {

    traversalObject(obj: any): Array<JSX.Element> {
        let list: Array<JSX.Element> = [];
        let i = 0;
        for (let a in obj) {
            if (typeof (obj[a]) == "object") {
                list.push(<ListGroupItem key={i++}>{a}: </ListGroupItem>);
                list.push(
                    <ListGroupItem key={i++}>
                        <ListGroup>
                            {this.traversalObject(obj[a])}
                        </ListGroup>
                    </ListGroupItem>
                );
            } else {
                list.push(<ListGroupItem key={i++}>{a}: {obj[a]}</ListGroupItem>);
            }
        }
        return list;
    }

    render() {
        let listItems: Array<JSX.Element> = this.traversalObject(this.props.data);
        return (
            <Col xs="12">
                <ListGroup>
                    {listItems}
                </ListGroup>
            </Col>
        );
    }
}