import { Pipe, PipeTransform } from '@angular/core';
import { AwardList } from 'src/app/models/award/award-list';

@Pipe({
  name: 'formatAward'
})
export class FormatAwardPipe implements PipeTransform {

  transform(value: AwardList) {
    const year = value.year;
    let result = value.title;
    if (year > 0) {
      result += ` Of ${year}`;
    }
    return result;
  }

}
