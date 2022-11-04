import { PipeTransform, Pipe } from '@angular/core';


@Pipe({
  name: 'timelapse'
})
export class TimelapsePipe implements PipeTransform {
  transform(value: number) {
    const hours = Math.floor(value);
    const minutes = Math.round(Math.abs(value - hours) * 60);
    let result = `${hours} hours`;
    if (minutes > 0 && minutes < 60) {
      result += ` and ${minutes} min`;
    }
    return result;
  }
}