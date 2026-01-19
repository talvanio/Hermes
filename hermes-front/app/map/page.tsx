"use client"

import dynamic from "next/dynamic";
import { useGlobalTheme } from "@/app/ThemeProvider";
import HermesLoading from "@/components/HermesLoading";

const Map = dynamic(
  () => import('@/components/Map'),
  { 
    loading: () => <HermesLoading />,
    ssr: false 
  }
);


export default function MapScreen() {
  const { theme } = useGlobalTheme() 
  return (
      <div className="h-screen w-full">
        <Map theme={theme} className="w-screen h-screen" position={[-19.926252,-43.945999]} zoom={16} />
      </div>
  );
}