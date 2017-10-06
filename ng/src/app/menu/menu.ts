export class Menu {
	display: string;
	href: string;
	tooltip: string;

	constructor(display: string, href: string, tooltip: string) { //initializes
			this.display = display;
			this.href = href;
			this.tooltip = tooltip;
	}
}