import {Button} from '@/components/shadcn/ui/button';
import { Input } from '@/components/shadcn/ui/input';

export default function LoginScreen() {
    return (
        <div className="flex items-center justify-center min-h-screen">
            <div className="w-96 space-y-6">
                <h1 className="scroll-m-20 text-center text-4xl font-extrabold tracking-tight text-balance">Hermes: Urban Dispatcher System</h1>
                <Input className='width=5' placeholder="username" />
                <div className="flex w-full max-w-sm items-center gap-2">
                    <Input type="text" placeholder="password" />
                    <Button type="submit" variant="outline">
                        login
                    </Button>
                </div>

            </div>
        </div>
    )
}