import React from "react";

export class Clock extends React.Component<any, any> {
    constructor(props: any) {
        super(props);
        this.state = { time: "" };
    }
    showTime() {
        let myDate = new Date();
        let showStr: string = '现在是 ' + myDate.getFullYear() + '-' + (myDate.getMonth() + 1) + '-' + myDate.getDate();
        //showStr += ' 星期' + '日一二三四五六'.charAt(myDate.getDay()) + '\r' + this.zerofill(myDate.getHours()) + ':' + this.zerofill(myDate.getMinutes()) + ':' + this.zerofill(myDate.getSeconds());
        showStr += ' 星期' + '日一二三四五六'.charAt(myDate.getDay()) + ' ' + this.zerofill(myDate.getHours()) + ':' + this.zerofill(myDate.getMinutes());
        this.setState({ time: showStr });
    }
    zerofill(s: string | number): string {
        let ss = parseFloat(s.toString().replace(/(^[\s0]+)|(\s+$)/g, ''));
        ss = isNaN(ss) ? 0 : ss;
        return (ss < 10 ? '0' : '') + ss.toString();
    }
    componentDidMount() {
        this.showTime();
        window.setInterval(this.showTime.bind(this), this.props.pollInterval);
    }
    render() {
        return (
            <span>{this.state.time}</span>
        );
    }
}