import React, {Component} from 'react';
import {Input} from "reactstrap";
import {emit} from './emit';

const SUPPORTED_LOCALES = [
    {
        name: 'English',
        value: 'en'
    },
    {
        name: '简体中文',
        value: 'zh'
    },
];

export default class LanguageSelector extends Component<any, any> {

    handleChange = (event: any) => {
        console.log("val:", event.target.value);
        emit.emit('change_language', event.target.value);
    }

    render() {
        let defaultOption = ((navigator.languages && navigator.languages[0]) || navigator.language)
            .split('-')[0];
        //console.log(defaultOption);
        return (
            <Input
                type='select'
                name='select'
                onChange={(e) => this.handleChange(e)}
                defaultValue={defaultOption}
            >
                {
                    SUPPORTED_LOCALES.map(locale => (
                            <option key={locale.value} value={locale.value}>
                                {locale.name}
                            </option>
                        )
                    )
                }
            </Input>
        );
    }
}