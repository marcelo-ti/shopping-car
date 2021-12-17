import { browser, by, element } from 'protractor'

export class AppPage {
  navigateTo() {
    return browser.get('/')
  }

  getMainHeading() {
    return element(by.css('app-root div a')).getText()
  }
}
