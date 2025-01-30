//namespace DanAutoPower.wwwroot.js


//import React, { useState } from "react";
//import ReactDOM from "react-dom";
//import { Card, CardContent } from "@/components/ui/card";
//import { Button } from "@/components/ui/button";
//import { Search } from "lucide-react";

//// Данни за автомобили
//const cars = [
//    { id: 1, name: "BMW X5", year: 2020, km: 120000, fuel: "Дизел", price: "€28,500", img: "https://source.unsplash.com/400x300/?bmw" },
//    { id: 2, name: "Audi A6", year: 2019, km: 98000, fuel: "Бензин", price: "€25,000", img: "https://source.unsplash.com/400x300/?audi" },
//    { id: 3, name: "Mercedes C-Class", year: 2021, km: 50000, fuel: "Хибрид", price: "€35,000", img: "https://source.unsplash.com/400x300/?mercedes" },
//    { id: 4, name: "Volkswagen Golf", year: 2018, km: 150000, fuel: "Дизел", price: "€18,000", img: "https://source.unsplash.com/400x300/?golf" },
//    { id: 5, name: "Tesla Model 3", year: 2022, km: 20000, fuel: "Електрически", price: "€40,000", img: "https://source.unsplash.com/400x300/?tesla" },
//    { id: 6, name: "Ford Focus", year: 2017, km: 170000, fuel: "Бензин", price: "€14,500", img: "https://source.unsplash.com/400x300/?ford" },
//];

//function DanAutoPower() {
//    const [search, setSearch] = useState("");
//    const [selectedCar, setSelectedCar] = useState(null);

//    // Филтриране на автомобили по търсене
//    const filteredCars = cars.filter(car => car.name.toLowerCase().includes(search.toLowerCase()));

//    return (
//        <div className="min-h-screen bg-gray-100 p-6">
//            <header className="bg-white shadow-lg p-4 flex justify-between items-center">
//                <h1 className="text-2xl font-bold">Автокъща DanAutoPower</h1>
//                <div className="flex items-center border border-gray-300 rounded-md p-2 bg-white">
//                    <Search className="mr-2 text-gray-500" size={18} />
//                    <input
//                        type="text"
//                        placeholder="Търси автомобил..."
//                        className="outline-none bg-transparent"
//                        value={search}
//                        onChange={(e) => setSearch(e.target.value)}
//                    />
//                </div>
//            </header>

//            <main className="mt-6 grid grid-cols-1 md:grid-cols-3 gap-6">
//                {filteredCars.length > 0 ? (
//                    filteredCars.map((car) => (
//                        <Card key={car.id} className="bg-white shadow-md rounded-lg overflow-hidden">
//                            <img src={car.img} alt={car.name} className="w-full h-48 object-cover" />
//                            <CardContent className="p-4">
//                                <h2 className="text-xl font-semibold">{car.name}</h2>
//                                <p className="text-gray-500">Година: {car.year} | {car.km} км | {car.fuel}</p>
//                                <p className="text-lg font-bold mt-2">{car.price}</p>
//                                <Button className="mt-3 w-full" onClick={() => setSelectedCar(car)}>
//                                    {selectedCar?.id === car.id ? "Затвори" : "Виж повече"}
//                                </Button>
//                                {selectedCar?.id === car.id && (
//                                    <div className="mt-3 p-2 bg-gray-100 rounded">
//                                        <p className="text-sm text-gray-600">Този автомобил е наличен за тестово шофиране.</p>
//                                    </div>
//                                )}
//                            </CardContent>
//                        </Card>
//                    ))
//                ) : (
//                    <p className="col-span-3 text-center text-gray-500">Няма намерени автомобили.</p>
//                )}
//            </main>
//        </div>
//    );
//}

//// Рендериране на компонента в HTML
//const rootElement = document.getElementById("root");
//if (rootElement) {
//    ReactDOM.render(<DanAutoPower />, rootElement);
//}

//export default DanAutoPower;
