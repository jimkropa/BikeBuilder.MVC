import {ComponentAnnotation as Component, ViewAnnotation as View} from 'angular2/angular2';

@Component({
  selector: 'bike-builder-angular-js'
})

@View({
  templateUrl: 'bike-builder-angular-js.html'
})

export class BikeBuilderAngularJs {

  constructor() {
    console.info('BikeBuilderAngularJs Component Mounted Successfully');
  }

}
