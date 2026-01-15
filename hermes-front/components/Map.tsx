import { MapContainer, Marker, Popup, GeoJSON, TileLayer } from "react-leaflet"
import { useTheme } from "@/hooks/use-theme"

import "leaflet/dist/leaflet.css"
import "leaflet-defaulticon-compatibility"
import "leaflet-defaulticon-compatibility/dist/leaflet-defaulticon-compatibility.css"


export default function Map(props: any) {
    const { position, zoom, theme } = props
    const testRouteData = {
            "type": "FeatureCollection",
            "features": [
                {
                    "type": "Feature",
                    "geometry": {
                        "type": "LineString",
                        "coordinates": [
                            [-43.950212, -19.922809, 865.5],
                            [-43.950648, -19.922708, 869.0],
                            [-43.950964, -19.92396, 877.0],
                            [-43.949681, -19.924283, 865.0],
                            [-43.948733, -19.924488, 869.0],
                            [-43.948505, -19.924538, 869.0],
                            [-43.948313, -19.924581, 874.0],
                            [-43.947091, -19.924889, 874.0],
                            [-43.945901, -19.925182, 880.0],
                            [-43.945734, -19.925223, 869.0],
                            [-43.944514, -19.925521, 870.0],
                            [-43.943329, -19.925816, 865.0],
                            [-43.943244, -19.925949, 876.0],
                            [-43.94247, -19.927193, 863.0],
                            [-43.942292, -19.92748, 863.0],
                            [-43.942171, -19.927687, 870.0],
                            [-43.941908, -19.92812, 870.0],
                            [-43.941838, -19.928241, 870.0],
                            [-43.941558, -19.928706, 868.0],
                            [-43.94141, -19.929021, 868.0],
                            [-43.941424, -19.929274, 878.0],
                            [-43.941751, -19.930158, 877.0],
                            [-43.942649, -19.929929, 871.5]
                        ]
                    }
                }
            ]
        };
    const lightUrl = "https://{s}.basemaps.cartocdn.com/light_all/{z}/{x}/{y}{r}.png";
    const darkUrl = "https://{s}.basemaps.cartocdn.com/dark_all/{z}/{x}/{y}{r}.png";
    
    return (
        <MapContainer 
        center={position} 
        zoom={zoom} 
        scrollWheelZoom={true} 
        style={{ height: "100%", width: "100%" }}
        >


            <TileLayer
            attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors &copy; <a href="https://carto.com/attributions">CARTO</a>'
            url={theme === 'light' ? lightUrl : darkUrl}
            key={theme}
            />
            <GeoJSON data={testRouteData as any} 
            style={() => ({
                    color: "#ff7700",
                    weight: 6,
                    opacity: 0.3,
                })}
            />
            <GeoJSON 
                data={testRouteData as any} 
                style={{
                    color: "#FFAA33",
                    weight: 6,
                    opacity: 0.65,
                    className: 'route-flow'
                }}
            />
        </MapContainer>
    )
    }