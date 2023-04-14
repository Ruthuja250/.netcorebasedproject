import { Component, OnInit } from '@angular/core';
declare var faqs : any;
@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.css']
})
export class FAQComponent implements OnInit{

  ngOnInit(): void {
    new faqs();
  }
  title='app-js'
}

