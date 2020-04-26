import React, {Component, ReactNode} from 'react';
import {Clock} from "../utils/Clock"

export class Footer extends Component {
    render(): ReactNode {
        return (
            <footer  className="text-center">
                <small>&copy; 2020 - Molfinder</small>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <small>
                    <Clock pollInterval={60000}/>
                </small>
            </footer>
        );
    }
}