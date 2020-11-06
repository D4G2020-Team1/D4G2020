import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
/** header component*/
export class HeaderComponent implements OnInit {
/** header ctor */

    detailOpened: boolean;

    constructor() {

    }

    ngOnInit() {
        this.detailOpened = false;
    }
}
