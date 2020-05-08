import React from './react';
import { Jumbotron, Button } from './reactstrap';
import {
    Card, CardImg, CardTitle, CardImgOverlay
} from './reactstrap';

class AppGrid extends React.Component {
    render() {
        const apps = this.props.children ? this.props.children : [];

        const appCount = apps.length;
        const appRemainder = appCount % 3;
        let rowCount = (appCount - appRemainder) / 3;

        if (appRemainder > 0) {
            rowCount++;
        }

        const appRows = [];

        let appCounter, rowCounter = 0;

        do {
            const appsRemaining = appCount - appCounter;
            if (appsRemaining > 3) {
                appRows.push(<AppRow>{apps.slice(appCounter, appCounter + 3)}</AppRow>);
                appCounter += 3;
            } else {
                appRows.push(<AppRow></AppRow>);
            }
            //TODO: continue hereabouts
            rowCounter++;
        } while (rowCounter <= rowCount);

        const onClick = () => {
            //TODO: navigate to settings
        };

        return appCount > 0 ? appRows : (
            <Jumbotron>
                <h1 className="display-3">It sure is empty in here!</h1>
                <p className="lead">
                    You can add new apps from the settings.
                </p>
                <hr className="my-2" />
                <p className="lead">
                    <Button color="primary" onClick={onClick} />
                </p>
            </Jumbotron>
        );
    }


}

class AppRow extends Component {
    render() {
        const apps = this.props.children;

        const appCards = [];

        apps?.forEach(function (item) {
            <BasicApp url={item.url} icon={item.icon} name={item.name} />
        });

        return (
            <div className="row align-items-center justify-content-center">
                {appCards}
            </div>
        );
    }
}

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