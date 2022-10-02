import axios from 'axios'
import React, { useEffect, useState } from 'react'

function LeavesChart() {
    const [chartData,setChartData]=useState({})
    const [empLeave,setEmpLeave]=useState([])
    const [empGrade,setEmpGrade]=useState([])
const chart=()=>{
    let jbgr_id=[];
    let jbgr_nocl=[]
    let jbgr_nool =[]
    let jbgr_nosl=[]
    let jbgr_totalnol=[]

    axios.get("/jobGradeWiseLeave").then((res)=>{
        console.log(res)
        for( const dataObj of res?.data?.gradeWiseLeaveData){
            jbgr_id.push(parseInt(dataObj?.jbgr_id))
            jbgr_nocl.push(parseInt(dataObj?.jbgr_nocl))
            jbgr_nool.push(parseInt(dataObj?.jbgr_nool))
            jbgr_nosl.push(parseInt(dataObj?.jbgr_nosl))
            jbgr_totalnol.push(parseInt(dataObj?.jbgr_totalnol))
        }
    }).catch((err)=>console.log(err))

    setChartData({
        
    })
}

useEffect(()=>{
    chart()
},[])

  return (
    <div>
      hii job
    </div>
  )
}

export default LeavesChart
