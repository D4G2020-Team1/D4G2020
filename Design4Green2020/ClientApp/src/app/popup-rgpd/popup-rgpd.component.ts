import { Component } from '@angular/core';

@Component({
    selector: 'app-popup-rgpd',
    templateUrl: './popup-rgpd.component.html',
    styleUrls: ['./popup-rgpd.component.scss']
})
export class PopupRgpdComponent {
    fermerModale() {
        document.getElementById('modal-rgpd').style.display = 'none';
    }
}
