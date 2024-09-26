import { Component, OnInit, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-image-slider',
  templateUrl: './image-slider.component.html',
  styleUrls: ['./image-slider.component.scss']
})
export class ImageSliderComponent implements OnInit, OnDestroy {
  images: string[] = [
    'assets/banner/Saree-1.png',
    'assets/banner/Saree-3.png',
  ];
  currentSlide = 0;
  interval: any;

  ngOnInit(): void {
    this.startSlider();
  }

  ngOnDestroy(): void {
    this.stopSlider();
  }

  startSlider(): void {
    this.interval = setInterval(() => {
      this.currentSlide = (this.currentSlide + 1) % this.images.length; // Cycle through images
    }, 5000); // Change slide every 5 seconds
  }

  stopSlider(): void {
    if (this.interval) {
      clearInterval(this.interval);
    }
  }
}
