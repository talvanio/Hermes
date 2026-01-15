"use client"

import dynamic from "next/dynamic";
import Image from "next/image";
import { useMemo } from "react";
import { ThemeProvider, useGlobalTheme } from "./ThemeProvider";

const Map = dynamic(
  () => import('@/components/Map'),
  { 
    loading: () => <p>A map is loading</p>,
    ssr: false 
  }
);


export default function Home() {
  const { theme } = useGlobalTheme() 
  return (
      <div className="h-screen w-full">
        <Map theme={theme} className="w-screen h-screen" position={[-19.926252,-43.945999]} zoom={16} />
      </div>
  );
}