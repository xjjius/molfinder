import React, {Component} from 'react';

export default class MolImage extends Component<any, any> {
    constructor(props: any) {
        super(props);
        this.state = {dataUrl: ""};
    }

    componentDidMount(): void {
        let submitUrl: string = "/api/molimg";
        fetch(submitUrl, {
            method: 'POST',
            body: JSON.stringify(this.props.molBase),
            headers: {
                'Content-Type': 'application/json;charset=UTF-8'
            },
            mode: 'cors',
            cache: 'default'
        })
            .then(response => response.text())
            .then(result => {
                console.log(result);
                this.setState({dataUrl: result});
            })
            .catch(e => console.log("Oops, error", e));
    }

    render() {
        return (
            <div className='m-auto'>
                <img src={this.state.dataUrl}
                     alt={"MolImage"}
                     className='img-responsive'
                     style={{maxWidth:"60em", maxHeight:"20cm"}}
                />
            </div>
        );
    }
}