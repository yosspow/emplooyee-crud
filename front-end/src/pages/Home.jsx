import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom';
import { Button } from 'antd';

export default function Home() {
    const [employees,setEmployees]= useState([]);

    useEffect(() => {
      const getEmployees = async ()=>{
        try {
      const data =  await  axios.get("http://localhost:5000/api/employees")
       
          setEmployees(data.data)
      
        } catch (error) {
            console.log(error);
        }

      }
      getEmployees();
    
    }, []);

    const handleDelete = (id)=>{
        if (window.confirm("do you really want to delete this employee ")) {
          try {
            const res =  axios.delete(`http://localhost:5000/api/employees/${id}`)
            setEmployees(employees.filter(emp => emp.id != id))
          } catch (error) {
            console.log(console.error(error));
          }  
        }
       
    }

  return (
    <>
    <Link className='w-full' to={"/employee-add"}>
    <Button type="primary" >
        Add Employee
    </Button>
    </Link>
   
    
<section className="container mx-auto p-6 font-mono">

  <div className="w-full mb-8  rounded-lg shadow-lg">
    <div className="w-full ">
      <table className="w-full">
        <thead>
          <tr className="text-md font-semibold tracking-wide text-left text-gray-900 bg-gray-100 uppercase border-b border-gray-600">
     
            <th className="px-4 py-3">Employee</th>
            
          
            <th className="px-4 py-3">Email</th>

            <th className="px-4 py-3">PhoneNumber</th>
            <th className="px-4 py-3">department</th>

            <th className="px-4 py-3">Actions</th>


          </tr>
        </thead>
        <tbody className="bg-white">
  
        {employees?.map((emp)=>(
             <tr className="text-gray-700" key={emp.id}>
             <td className="px-4 py-3 border">
               <div className="flex items-center text-sm">
                 <div className="relative w-8 h-8 mr-3 rounded-full md:block">
                   <img className="object-cover  rounded-full" src="https://i.pinimg.com/736x/ea/ae/54/eaae54fd870939822d500c960aa42fbe.jpg" alt="" loading="lazy" />
                   <div className="absolute inset-0 rounded-full shadow-inner" aria-hidden="true"></div>
                 </div>
                 <div>
                   <p className="font-semibold text-black">{emp.firstName + " " + emp.lastName}</p>
                   <p className="text-xs text-gray-600">{emp.position}</p>
                 </div>
               </div>
             </td>
             <td className="px-4 py-3 text-ms font-semibold border">{emp.email}</td>
             <td className="px-4 py-3 text-xs font-bold border">
{emp.phoneNumber} 
             </td>
             <td className="px-4 py-3 text-sm border">{emp.department}</td>
             <td className="px-4 py-3  border">
 <Link to={`/edit/${emp.id}`} className="text-indigo-600 hover:text-indigo-700 mx-2">Edit</Link>
 <button onClick={()=>handleDelete(emp.id)}  className="text-red-600 hover:text-red-950">Delete</button>


             </td>

           </tr>
     ))}

        </tbody>
      </table>
    </div>
  </div>
</section>
</>

  )
}
