import { Component, OnInit } from '@angular/core';

import { ToastService } from './toast.service'

@Component({
    selector: 'agl-toast',
    templateUrl: './toast.component.html'
})
export class ToastComponent {

    public options = {
        timeOut: 5000,
        lastOnBottom: true,
        clickToClose: true,
        maxLength: 0,
        maxStack: 7,
        showProgressBar: true,
        pauseOnHover: true,
        preventDuplicates: false,
        preventLastDuplicates: "visible",
        rtl: false,
        animate: "scale",
        position: ["right", "bottom"]
    };
}
