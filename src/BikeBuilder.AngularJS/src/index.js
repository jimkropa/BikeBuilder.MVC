import {ComponentAnnotation as Component, ViewAnnotation as View, bootstrap} from 'angular2/angular2';
import {BikeBuilderAngularJs} from 'bike-builder-angular-js';

@Component({
  selector: 'main'
})

@View({
  directives: [BikeBuilderAngularJs],
  template: `
    <bike-builder-angular-js></bike-builder-angular-js>
  `
})

class Main {

}

bootstrap(Main);
