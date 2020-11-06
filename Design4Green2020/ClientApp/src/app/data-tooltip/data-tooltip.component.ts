import { Component, Input } from '@angular/core';
import { Score } from '../models/score';

@Component({
    selector: 'app-data-tooltip',
    templateUrl: './data-tooltip.component.html',
    styleUrls: ['./data-tooltip.component.scss']
})
/** data-tooltip component*/
export class DataTooltipComponent {
/** data-tooltip ctor */
    @Input() data: Score;

    constructor() {

    }

    setColor(i: number) {
        let couleur = "#5DA6BD";
        if (i < 70) {
            couleur = "#BEE1DA"
        } else if (i > 70 && i < 100) {
            couleur = "#7ABBC8";
        }
        else if (i >= 130) {
            couleur = "#5E757D";
        }
        return couleur;
    }
}
