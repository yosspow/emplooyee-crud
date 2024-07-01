import { useState } from 'react'

import './App.css'
import {Routes, Route, BrowserRouter } from 'react-router-dom';
import Home from './pages/Home';
import AddEmp from './pages/AddEmp';
import EditEmp from './pages/EditEmp';
function App() {


  return (
    <>
  <BrowserRouter>
  <Routes>
<Route path='/' element={<Home/>}/>
<Route path='/employee-add' element={<AddEmp/>}/>
<Route path='/edit/:id' element={<EditEmp/>}/>


  </Routes>
  </BrowserRouter>


    </>
  )
}

export default App
