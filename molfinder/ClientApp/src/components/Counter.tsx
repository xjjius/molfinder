import React, {Component} from 'react';
import {Link} from "react-router-dom";

export class Counter extends Component<any, any> {
    static displayName = Counter.name;

    constructor(props: any) {
        super(props);
        this.state = {currentCount: 0};
        this.incrementCounter = this.incrementCounter.bind(this);
    }

    incrementCounter() {
        this.setState({
            currentCount: this.state.currentCount + 1
        });
    }

    render() {
        return (
            <div>
                <h1>Counter</h1>

                <p>This is a simple example of a React component.</p>

                <p aria-live="polite">Current count: <strong>{this.state.currentCount}</strong></p>

                <button className="btn btn-primary" onClick={this.incrementCounter}>Increment</button>

                <p>
                    <Link to={'/molecule/' + this.state.currentCount}>Molecule</Link>
                </p>
            </div>
        );
    }
}
