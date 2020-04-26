import React, {Component} from 'react';
import {Route} from 'react-router';
import {Layout} from './components/layouts/Layout';
import {Home} from './components/Home';
import {FetchData} from './components/FetchData';
import {Counter} from './components/Counter';
import intl from "react-intl-universal";
import {emit} from "./components/utils/emit";
import './custom.css'
import {MoleculePage} from "./components/molecule/MoleculePage";
import labels from "./config/Labels";

require('intl/locale-data/jsonp/en.js');
require('intl/locale-data/jsonp/zh.js');

const locales = {
    'en': require('./locales/en-US.json'),
    'zh': require('./locales/zh-CN.json'),
};

let defaultLang = (navigator.languages && navigator.languages[0]) || navigator.language;

export default class App extends Component<any, any> {
    constructor(props: any) {
        super(props);
        this.state = {initDone: false, initLabelsDone: false};
    }

    static displayName = App.name;

    componentDidMount() {
        this.loadLocales();
        this.initLabels();
        emit.on('change_language', (lang: string) => this.loadLocales(lang));
    }

    loadLocales(lang = defaultLang.split('-')[0]) {
        // init method will load CLDR locale data according to currentLocale
        // react-intl-universal is singleton, so you should init it only once in your app
        console.log(lang);
        intl.init({
            currentLocale: lang,
            locales,
        })
            .then(() => {
                this.setState({initDone: true});
            });
    }

    initLabels() {
        let submitUrl = '/api/config';
        //alert(submitUrl);
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
                //alert(result);
                console.log(result);
                labels.config = result;
                console.log('config loaded from server');
                //localStorage.setItem("config", JSON.stringify(result));
                //console.log(localStorage["config"]);
                this.setState({initLabelsDone: true});
            })
            .catch(e => console.log("Oops, error", e));
    }

    render() {
        if (this.state.initDone && this.state.initLabelsDone) {
            return (
                <Layout>
                    <Route exact path='/' component={Home}/>
                    <Route path='/counter' component={Counter}/>
                    <Route path='/fetch-data' component={FetchData}/>
                    <Route path='/molecule/:molId'
                           render={({match}) => <MoleculePage molId={match.params.molId}/>}/>
                </Layout>
            );
        } else {
            return (
                <Layout>
                    Loading...
                </Layout>
            );
        }
    }
}