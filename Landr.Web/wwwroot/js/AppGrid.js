var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
import React from './react';
import { Jumbotron, Button } from './reactstrap';
import { Card, CardImg, CardTitle, CardImgOverlay } from './reactstrap';
var AppGrid = /** @class */ (function (_super) {
    __extends(AppGrid, _super);
    function AppGrid() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    AppGrid.prototype.render = function () {
        var apps = this.props.children ? this.props.children : [];
        var appCount = apps.length;
        var appRemainder = appCount % 3;
        var rowCount = (appCount - appRemainder) / 3;
        if (appRemainder > 0) {
            rowCount++;
        }
        var appRows = [];
        var appCounter, rowCounter = 0;
        do {
            var appsRemaining = appCount - appCounter;
            if (appsRemaining > 3) {
                appRows.push(React.createElement(AppRow, null, apps.slice(appCounter, appCounter + 3)));
                appCounter += 3;
            }
            else {
                appRows.push(React.createElement(AppRow, null));
            }
            //TODO: continue hereabouts
            rowCounter++;
        } while (rowCounter <= rowCount);
        var onClick = function () {
            //TODO: navigate to settings
        };
        return appCount > 0 ? appRows : (React.createElement(Jumbotron, null,
            React.createElement("h1", { className: "display-3" }, "It sure is empty in here!"),
            React.createElement("p", { className: "lead" }, "You can add new apps from the settings."),
            React.createElement("hr", { className: "my-2" }),
            React.createElement("p", { className: "lead" },
                React.createElement(Button, { color: "primary", onClick: onClick }))));
    };
    return AppGrid;
}(React.Component));
var AppRow = /** @class */ (function (_super) {
    __extends(AppRow, _super);
    function AppRow() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    AppRow.prototype.render = function () {
        var apps = this.props.children;
        var appCards = [];
        apps === null || apps === void 0 ? void 0 : apps.forEach(function (item) {
            React.createElement(BasicApp, { url: item.url, icon: item.icon, name: item.name });
        });
        return (React.createElement("div", { className: "row align-items-center justify-content-center" }, appCards));
    };
    return AppRow;
}(Component));
var BasicApp = /** @class */ (function (_super) {
    __extends(BasicApp, _super);
    function BasicApp() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    BasicApp.prototype.render = function () {
        var url = this.props.url;
        var icon = this.props.icon;
        var name = this.props.name;
        var defaultContent = (React.createElement("div", { className: "col-sm-4" },
            React.createElement("a", { href: url },
                React.createElement(Card, { inverse: true },
                    React.createElement(CardImg, { width: "100%", src: icon, alt: name }),
                    React.createElement(CardImgOverlay, null,
                        React.createElement(CardTitle, null, name))))));
        return this.props.children ? this.props.children : defaultContent;
    };
    return BasicApp;
}(Component));
//# sourceMappingURL=AppGrid.js.map