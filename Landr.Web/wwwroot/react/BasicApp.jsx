import React, { Component } from 'react';
import {
    Card, CardImg, CardText, CardBody,
    CardTitle, Button, CardImgOverlay
} from 'reactstrap';

class BasicApp extends Component {
    render() {
        const url = this.props.url;
        const icon = this.props.icon;
        const name = this.props.name;

        const defaultContent = (
            <div className="col-sm-4">
                <a href={url}>
                    <Card inverse>
                        <CardImg width="100%" src={icon} alt={name} />
                        <CardImgOverlay>
                            <CardTitle>{name}</CardTitle>
                        </CardImgOverlay>
                    </Card>
                </a>
            </div>
        );

        return this.props.children ? this.props.children : defaultContent;
    }
}