import React, {Component} from "react";

export default class PubChemBioAssay extends Component <any, any> {
    render() {
        if (this.props.pubChemCID) {
            let url = "https://pubchem.ncbi.nlm.nih.gov/compound/"
                + this.props.pubChemCID
                + "#section=BioAssay-Results&embed=true&hide_title=true";
            return (
                <iframe id='pubchem_bioassay'
                        title="pubchem-bioassay"
                        className="pubchem-widget"
                        scrolling="no"
                    /*onLoad={() => {
                        this.setState({
                            isLoaded: true
                        });
                    }}*/
                        src={url}
                        style={{border: 0, width: '100%', height: '700px', overflow: 'visible'}}
                        sandbox="allow-same-origin allow-scripts allow-popups allow-forms"
                />
            );
        } else {
            return (
                "Loading..."
            );
        }
    }
}