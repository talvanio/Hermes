import {Button} from '@/components/shadcn/ui/button';
import { Input } from '@/components/shadcn/ui/input';

export default function LoginScreen() {
    return (
        <div className="flex flex-col items-center justify-center min-h-screen px-4">
            <h1 className="scroll-m-20 text-center text-2xl sm:text-3xl md:text-4xl font-extrabold tracking-tight text-balance absolute top-40 sm:top-16 md:top-45 max-w-xs sm:max-w-md md:max-w-2xl">
                <span className="text-orange-400">HERMES:</span> An Urban Dispatcher System
            </h1>

            <div className="w-full max-w-sm md:max-w-md space-y-4">
                <Input placeholder="Username" />
                <Input type="Password" placeholder="Password" />
                <Button type="submit" variant="outline" className="w-full h-15">
                    Login
                </Button>
            </div>
        </div>
    )
}