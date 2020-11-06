import { Component } from '@angular/core';

@Component({
  selector: 'app-popup-info',
  templateUrl: './popup-info.component.html',
  styleUrls: ['./popup-info.component.scss']
})
export class PopupInfoComponent {
    fermerModale() {
        document.getElementById('modal-info').style.display = 'none';
    }

}
