import { Component, Input } from '@angular/core';
import { Score } from '../models/score';

@Component({
    selector: 'app-score',
    templateUrl: './score.component.html',
    styleUrls: ['./score.component.scss']
})
/** score component*/
export class ScoreComponent {
    /** score ctor */
    @Input() score: Score;

    Exporter() {
        window.location.href = `api/Pdf/Presentation?codeIris=${this.score.codeIris}`;
    }

    tronquerNombre(nombre: number) {
        return Math.floor(nombre);
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
