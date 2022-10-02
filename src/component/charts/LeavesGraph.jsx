import React from 'react';
import CanvasJSReact from './canvasjs.react';
// var CanvasJS = CanvasJSReact.CanvasJS;
var CanvasJSChart = CanvasJSReact.CanvasJSChart;
 
function LeavesGraph() {	
	
		const options = {
			animationEnabled: true,
			exportEnabled: true,
			theme: "light1", // "light1", "dark1", "dark2"
			title:{
				text: "Leaves & Permissions Graph"
			},
			data: [{
				type: "pie",
				indexLabel: "{label}: {y}%",		
				startAngle: -90,
				dataPoints: [
					{ y: 4, label: "January" },
					{ y: 5, label: "February" },
					{ y: 2, label: "March" },
					{ y: 8, label: "April" },
					{ y: 1, label: "May" },
					{ y: 0, label: "June" },	
					{ y: 2, label: "July" },	
					{ y: 4, label: "August" },	
					{ y: 10, label: "September" },	
					{ y: 8, label: "October" },	
					{ y: 7, label: "November" },	
					{ y: 0, label: "December" },	
				]
			}]
		}
		
		return (
		<div>
			<CanvasJSChart options = {options} 
				/* onRef={ref => this.chart = ref} */
			/>
			{/*You can get reference to the chart instance as shown above using onRef. This allows you to access all chart properties and methods*/}
		</div>
		);
	}

 
export {LeavesGraph}