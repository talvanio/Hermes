"use client"
import { createContext, useContext, ReactNode } from 'react'
import { useTheme } from '@/hooks/use-theme'

const ThemeContext = createContext<any>(null)

export function ThemeProvider({ children }: { children: ReactNode }) {
    const themeData = useTheme()
    return (
        <ThemeContext.Provider value={themeData}>
            {children}
        </ThemeContext.Provider>
    )
}

export const useGlobalTheme = () => useContext(ThemeContext)